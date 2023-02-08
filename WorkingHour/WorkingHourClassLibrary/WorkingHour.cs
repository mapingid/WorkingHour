namespace WorkingHourClassLibrary
{
  
  class FMLXTime
  {
    private int _Hour;
    private int _Minute;
    private int _Second;

    public int Hour  
    {
      get { return _Hour; }
      set { _Hour = value; }
    }
    public int Minute
    {
      get { return _Minute; }
      set 
      {
        _Minute = value;
        while( _Minute > 60)
        {
          _Hour++;
          _Minute -= 60;
        }
      }
    }

    public int Second
    {
      get { return _Second; }
      set
      {
        _Second = value;
        while( _Second > 60 )
        {
          _Minute++;
          _Second -= 60;
        }
      }
    }

    public FMLXTime(int hour, int minute, int second)
    {
      Hour= hour; Minute = minute; Second=second;
    }
    public FMLXTime( int hour, int minute )
    {
      Hour = hour; Minute = minute; Second = 0;
    }
    public FMLXTime( int hour)
    {
      Hour = hour; Minute = 0; Second = 0;
    }
  }


  public class FMLXWorkingHour
  {
    //FMLXTime ExpectedWorkingHour = new FMLXTime( 45 );
    //FMLXTime SuggestedWorkingHour = new FMLXTime( 9 );
    //FMLXTime BreakTime = new FMLXTime( 0,30 );

    List<FMLXTime> ListOfWeeklyWorkingHour = new List<FMLXTime>();

    public void Register(int hour, int minute, int second)
    {

    }

    public void Test()
    {
      FMLXTime a = new FMLXTime( 25,50 );

      Console.Write( a.Hour );Console.Write(" "); Console.Write( a.Minute );
    }



  }
}