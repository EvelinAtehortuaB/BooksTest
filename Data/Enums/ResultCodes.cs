namespace DataAccess.Enums
{
    public enum ResultCodes
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        Deleted = 220,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        ValidationError = 410,
        InternalServerError = 500,
        NotImplemented = 501,
    }
}
