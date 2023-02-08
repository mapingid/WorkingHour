using Microsoft.Win32;

namespace WorkingHourClassLibrary
{

  struct FMLXTime
  {
    int _Hour = 0;
    int _Minute = 0;
    int _Second = 0;

    public int Hour
    {
      get { return _Hour; }
      private set { _Hour = value; }
    }
    public int Minute
    {
      get { return _Minute; }
      private set
      {
        if( value > 0 )
        {
          _Minute = value;
          while( _Minute >= 60 )
          {
            _Hour++;
            _Minute -= 60;
          }
        }
        else if( value < 0 )
        {
          _Minute = value;
          while( _Minute < 0 )
          {
            _Hour--;
            _Minute += 60;
          }
        }

      }
    }
    public int Second
    {
      get { return _Second; }
      private set
      {
        if( value > 0 )
        {
          _Second = value;
          while( _Second >= 60 )
          {
            _Minute++;
            _Second -= 60;
          }
        }
        else if( value < 0 )
        {
          _Second = value;
          while( _Second < 0 )
          {
            _Minute--;
            _Second += 60;
          }
        }
      }
    }
    public string Value
    {
      get
      {
        return $"{Hour} : {Minute} : {Second}";
      }
    }
    public FMLXTime( int hour, int minute, int second )
    {
      Hour = hour; Minute = minute; Second = second;
    }
    public static FMLXTime operator +( FMLXTime a, FMLXTime b )
    {
      return new FMLXTime( a.Hour + b.Hour, a.Minute + b.Minute, a.Second + b.Second );
    }
    public static FMLXTime operator -( FMLXTime a, FMLXTime b )
    {
      return new FMLXTime( a.Hour - b.Hour, a.Minute - b.Minute, a.Second - b.Second );
    }
    public static FMLXTime operator /( FMLXTime a, int b )
    {
      return new FMLXTime( a.Hour / b, a.Minute / b, a.Second / b );
    }
  }




  public class FMLXWorkingHour
  {

    static FMLXTime LeftWorkingHour = new FMLXTime( 45, 0, 0 );
    static FMLXTime BreakTime = new FMLXTime( 0, 30, 0 );
    static FMLXTime SuggestionWorkingHour = new FMLXTime( 9, 0, 0 );
    static int WorkingDay = 5;

    public void Register( int hour, int minute, int second )
    {
      var temp = new FMLXTime( hour, minute, second );
      LeftWorkingHour = LeftWorkingHour - temp;
      WorkingDay--;
    }
    public void GetDailyRecommendation( int hour, int minute, int second )
    {
      var arrive = new FMLXTime( hour, minute, second );
      var recom = LeftWorkingHour / WorkingDay;
      recom += arrive + BreakTime;
      var suggest = arrive + SuggestionWorkingHour + BreakTime;

      Console.WriteLine( "DAILY RECOMMENDATION" );
      Console.WriteLine( $"AVG     : {recom.Value}" );
      Console.WriteLine( $"SUGGEST : {suggest.Value}" );

    }
    public void GetLeftWorkingHour()
    {
      Console.WriteLine( $"Left {LeftWorkingHour.Value} for {WorkingDay} days" );
    }

    public void Test()
    {
      Register( 09, 37, 23 );
      Register( 10, 1, 24 );


      GetDailyRecommendation( 7, 36, 48 );
      GetLeftWorkingHour();

    }



  }
}