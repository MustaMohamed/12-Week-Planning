﻿namespace WeeksPlanning.Migration
{
    public static class StringLength
    {
        public const int One = 1;
        public const int Two = 2;
        public const int Three = 3;
        public const int Five = 5;
        public const int Twelve = 12;
        public const int Thirteen = 13;
        public const int Twenty = 20;
        public const int Fifty = 50;
        public const int Hundred = 100;
        public const int TwoHundredFiftyFive = 255;
        public const int FiveHundredFifty = 550;
        public const int Thousand = 1000;
        public const int SuperExtraLong = 30000;
    }

    public static class SqlServerSpecificType
    {
        public const string Geometry = "geometry";
        public const string Identity = "int GENERATED BY DEFAULT AS IDENTITY";
        public const string IdentitySmall = "smallint GENERATED BY DEFAULT AS IDENTITY";
        public const string IdentityBig = "bigint GENERATED BY DEFAULT AS IDENTITY";
        public const string Jsonb = "jsonb";
        public const string Uuid = "uniqueidentifier";
        public const string Time = "time";
        public const string Timestamp = "timestamp";
        public const string Text = "text";
    }
}