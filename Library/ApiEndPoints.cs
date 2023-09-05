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

        public static class Book
        {
            public const string Base = $"{ApiBase}/Books";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}"; 
        }

        public static class Category
        {
            public const string Base = $"{ApiBase}/Categories";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Worker
        {
            public const string Base = $"{ApiBase}/Workers";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Customer
        {
            public const string Base = $"{ApiBase}/Customers";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class RentBook
        {
            public const string Base = $"{ApiBase}/RentBooks";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id:guid}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }
    }
}
