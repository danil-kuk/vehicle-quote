using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Validation;

namespace VehicleQuotes.Models;

[Index(nameof(FeatureType), nameof(FeatureValue), IsUnique = true)]
public class QuoteRule
{
    public static class FeatureTypes
    {
        public static readonly string BodyType = "BodyType";
        public static readonly string Size = "Size";
        public static readonly string ItMoves = "ItMoves";
        public static readonly string HasAllWheels = "HasAllWheels";
        public static readonly string HasAlloyWheels = "HasAlloyWheels";
        public static readonly string HasAllTires = "HasAllTires";
        public static readonly string HasKey = "HasKey";
        public static readonly string HasTitle = "HasTitle";
        public static readonly string RequiresPickup = "RequiresPickup";
        public static readonly string HasEngine = "HasEngine";
        public static readonly string HasTransmission = "HasTransmission";
        public static readonly string HasCompleteInterior = "HasCompleteInterior";

        public static string[] All => new string[] {
            BodyType, Size, ItMoves, HasAllWheels, HasAlloyWheels, HasAllTires,
            HasKey, HasTitle, RequiresPickup, HasEngine, HasTransmission, HasCompleteInterior
        };
    }

    public int ID { get; set; }

    [FeatureType]
    public required string FeatureType { get; set; }
    public required string FeatureValue { get; set; }
    public int PriceModifier { get; set; }
}
