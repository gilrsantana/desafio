namespace Livraria.Shared.Messages;

public static class Error
{
    public static class Common
    {
        public const string INVALID_SKIP_TAKE = 
            "Skip must be greater than or equal to zero and take must be greater than or equal to one.";
        public const string INVALID_ID = "INVALID_ID";
        
        public const string EMPTY_FIRST_NAME = "EMPTY_FIRST_NAME";
        public const string EMPTY_LAST_NAME = "EMPTY_LAST_NAME";
        public const string INVALID_FIRST_NAME = "INVALID_FIRST_NAME";
        public const string INVALID_LAST_NAME = "INVALID_LAST_NAME";
        public const string INVALID_MODEL = "INVALID_MODEL";
    }
    public static class Author
    {
        public const string NOT_FOUND= "AUTHOR_NOT_FOUND";
        public const string ALREADY_EXISTS = "AUTHOR_ALREADY_EXISTS";
        public const string INVALID_VALUE = "AUTHOR_INVALID_VALUES";
        public const string NOT_INSERTED = "AUTHOR_NOT_INSERTED";
        public const string NOT_UPDATED = "AUTHOR_NOT_UPDATED";

        public const string EMPTY_NAME = "EMPTY_NAME";
        public const string NAME_REQUIRED = "NAME_REQUIRED";
        public const string MIN_FIRSTNAME_LENGTH_3 = "MIN_FIRSTNAME_LENGTH_3";
        public const string MAX_FIRSTNAME_LENGTH_80 = "MAX_FIRSTNAME_LENGTH_80";
        public const string MAX_LASTNAME_LENGTH_80 = "MAX_LASTNAME_LENGTH_80";

        public const string BIRTHDATE_REQUIRED = "BIRTHDATE_REQUIRED";
        public const string INVALID_BIRTHDATE = "INVALID_BIRTHDATE";

        public const string MAX_NATIONALITY_LENGTH_80 = "MAX_NATIONALITY_LENGTH_80";

        public const string MAX_BIOGRAPHY_LENGTH_500 = "MAX_BIOGRAPHY_LENGTH_500";
    }
    
}