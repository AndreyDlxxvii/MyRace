namespace MyRaces
{
    public class ProfilePlayer
    { 
        public SubscribeProperty<GameState> CurrentState { get; }
        public CarModel CurrentCar { get; }
        
        public ProfilePlayer(float speed, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscribeProperty<GameState>();
            CurrentCar = new CarModel(speed);
            AnalyticsTool = new UnityAnalytiscTool();
            AdsShower = unityAdsTools;
        }
        
        public IAnalyticsTool AnalyticsTool { get; }
        
        public IAdsShower AdsShower { get; }
    }
}