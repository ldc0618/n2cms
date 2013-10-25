using System.Web;
public class SessionService
{
  // Private constructor (use MySession.Current to access the current instance).
  private SessionService() {}

  // Gets the current session.
  public static SessionService Current
  {
    get
    {
      SessionService session = HttpContext.Current.Session["__MySession__"] as SessionService;
      if (session == null)
      {
        session = new SessionService();
        HttpContext.Current.Session["__MySession__"] = session;
      }
      return session;
    }
  }

  // My session data goes here:
  public string UserName { get; set; }
  public string UserEmail { get; set; }
  public string DisplayName { get; set; }
  public int ProfileId { get; set; }
  public string ProfileUrl { get; set; }

}