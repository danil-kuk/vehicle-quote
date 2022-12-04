using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Data;
using VehicleQuotes.Models;
using VehicleQuotes.ResourceModels;

namespace VehicleQuotes.Services;

public class QuoteService
{
    private readonly VehicleQuotesContext _context;

    public QuoteService(VehicleQuotesContext context)
    {
        _context = context;
    }

    public async Task<List<SubmittedQuoteRequest>> GetAllQuotes()
    {
        IQueryable<SubmittedQuoteRequest> quotesToReturn = _context.Quotes.Select(q => new SubmittedQuoteRequest
        {
            ID = q.ID,
            CreatedAt = q.CreatedAt,
            OfferedQuote = q.OfferedQuote,
            Message = q.Message,

            Year = q.Year,
            Make = q.Make,
            Model = q.Model,
            BodyType = q.BodyType.Name,
            Size = q.Size.Name,

            ItMoves = q.ItMoves,
            HasAllWheels = q.HasAllWheels,
            HasAlloyWheels = q.HasAlloyWheels,
            HasAllTires = q.HasAllTires,
            HasKey = q.HasKey,
            HasTitle = q.HasTitle,
            RequiresPickup = q.RequiresPickup,
            HasEngine = q.HasEngine,
            HasTransmission = q.HasTransmission,
            HasCompleteInterior = q.HasCompleteInterior,
        });

        return await quotesToReturn.ToListAsync();
    }

    public async Task<SubmittedQuoteRequest> CalculateQuote(QuoteRequest request)
    {
        SubmittedQuoteRequest response = CreateResponse(request);
        Quote quoteToStore = await CreateQuote(request);
        ModelStyleYear? requestedModelStyleYear = await FindModelStyleYear(request);
        QuoteOverride? quoteOverride = null;

        if (requestedModelStyleYear != null)
        {
            quoteToStore.ModelStyleYear = requestedModelStyleYear;

            quoteOverride = await FindQuoteOverride(requestedModelStyleYear);

            if (quoteOverride != null)
            {
                response.OfferedQuote = quoteOverride.Price;
            }
        }

        if (quoteOverride == null)
        {
            response.OfferedQuote = await CalculateOfferedQuote(request);
        }

        if (requestedModelStyleYear == null)
        {
            response.Message = "Offer subject to change upon vehicle inspection.";
        }

        quoteToStore.OfferedQuote = response.OfferedQuote;
        quoteToStore.Message = response.Message;

        _context.Quotes.Add(quoteToStore);
        await _context.SaveChangesAsync();

        response.ID = quoteToStore.ID;
        response.CreatedAt = quoteToStore.CreatedAt;

        return response;
    }

    // Creates a `SubmittedQuoteRequest`, initialized with default values, using the data from the incoming
    // `QuoteRequest`. `SubmittedQuoteRequest` is what gets returned in the response payload of the quote endpoints.
    private static SubmittedQuoteRequest CreateResponse(QuoteRequest request)
    {
        return new SubmittedQuoteRequest
        {
            OfferedQuote = 0,
            Message = "This is our final offer.",

            Year = request.Year,
            Make = request.Make,
            Model = request.Model,
            BodyType = request.BodyType,
            Size = request.Size,

            ItMoves = request.ItMoves,
            HasAllWheels = request.HasAllWheels,
            HasAlloyWheels = request.HasAlloyWheels,
            HasAllTires = request.HasAllTires,
            HasKey = request.HasKey,
            HasTitle = request.HasTitle,
            RequiresPickup = request.RequiresPickup,
            HasEngine = request.HasEngine,
            HasTransmission = request.HasTransmission,
            HasCompleteInterior = request.HasCompleteInterior,
        };
    }

    // Creates a `Quote` based on the data from the incoming `QuoteRequest`. This is the object that gets eventually
    // stored in the database.
    private async Task<Quote> CreateQuote(QuoteRequest request)
    {
        return new Quote
        {
            Year = request.Year,
            Make = request.Make,
            Model = request.Model,
            BodyTypeID = (await _context.BodyTypes.SingleAsync(bt => bt.Name == request.BodyType)).ID,
            SizeID = (await _context.Sizes.SingleAsync(s => s.Name == request.Size)).ID,

            ItMoves = request.ItMoves,
            HasAllWheels = request.HasAllWheels,
            HasAlloyWheels = request.HasAlloyWheels,
            HasAllTires = request.HasAllTires,
            HasKey = request.HasKey,
            HasTitle = request.HasTitle,
            RequiresPickup = request.RequiresPickup,
            HasEngine = request.HasEngine,
            HasTransmission = request.HasTransmission,
            HasCompleteInterior = request.HasCompleteInterior,

            CreatedAt = DateTime.Now
        };
    }

    // Tries to find a registered vehicle that matches the one for which the quote is currently being requested.
    private Task<ModelStyleYear?> FindModelStyleYear(QuoteRequest request)
    {
        return _context.ModelStyleYears.FirstOrDefaultAsync(msy =>
            msy.Year == request.Year &&
            msy.ModelStyle.Model.Make.Name == request.Make &&
            msy.ModelStyle.Model.Name == request.Model &&
            msy.ModelStyle.BodyType.Name == request.BodyType &&
            msy.ModelStyle.Size.Name == request.Size
        );
    }

    // Tries to find an override for the vehicle for which the quote is currently being requested.
    private async Task<QuoteOverride?> FindQuoteOverride(ModelStyleYear modelStyleYear)
    {
        return await _context.QuoteOverrides
            .FirstOrDefaultAsync(quote => quote.ModelStyleYear == modelStyleYear);
    }

    // Uses the rules stored in the `quote_rules` table to calculate how much money to offer for the vehicle
    // described in the incoming `QuoteRequest`.
    private async Task<int> CalculateOfferedQuote(QuoteRequest request)
    {
        List<QuoteRule> rules = await _context.QuoteRules.ToListAsync();

        QuoteRule? theMatchingRule(string featureType) =>
            rules.Find(r =>
                r.FeatureType == featureType &&
                r.FeatureValue == request[featureType]
            );

        return QuoteRule.FeatureTypes.All
            .Select(theMatchingRule)
            .Where(rule => rule != null)
            .Sum(rule => rule?.PriceModifier ?? 0);
    }
}
