namespace Library
{
    public static class ApiEndPoints
    {
        private const string ApiBase = "Api";

        public static class Author
        {
            public const string Base = $"{ApiBase}/Authors";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }
    }
}
