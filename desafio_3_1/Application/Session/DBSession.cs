namespace DentalOffice.Application.DBSession;

using DentalOffice.Infra.DB;

public class DbSession
{
  public static readonly DentalOfficeDbContext Db = new();
}
