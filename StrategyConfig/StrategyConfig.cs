namespace Bot
{



    class StrategyConfig
    {

        string AccountId { get; set;}

        string Password { get; set;}
  
        string StrategyId { get; set;}

        enum Status {
            RUNNING,

            PAUSED,
            
            INACTIVE,
        }

        Status status {get; set;}
        
    }

}
