# SWResupplyCalculator

This console app computes the number of resupply stops needed for each Star Wars spaceship to go through a given distance. 

## How is the number of stops computed?
The distance divided by number of available supplies multiplied by the speed in MGLT of each starship. 

    var numberOfStops = distance / (ship.AvailableConsumablesInHours * ship.MGLT);

## How to run the application?
Download the source code. Open it with visual studio and start the application by pressing F5. (or click on the Play button in visual studio). 

Using VS Code: Open the folder with the code and using the terminal type:

    dotnet run --project .\src\ResupplyCalculator.ConsoleApplication\ResupplyCalculator.ConsoleApplication.csproj

Once prompted inform the distance and then the ordenation type (by name or by number of stops). 

Example:

    Welcome to the starship resupply calculator app.
    To start, please inform the distance in MGLT:
    :> 1000000 
    Great! We will compute the distance for each of the 36 starships.
    Would you like to get the results ordered by:
     1 - Name
     2 - Number of Stops
    :> 2
    _____________________________________________________
    Name                         || Total number of stops
    Droid control ship...........:> unknown
    Republic Cruiser.............:> unknown
    Scimitar.....................:> unknown
    Naboo Royal Starship.........:> unknown
    Naboo fighter................:> unknown
    Jedi starfighter.............:> unknown
    AA-9 Coruscant freighter.....:> unknown
    J-type diplomatic barge......:> unknown
    Solar Sailer.................:> unknown
    Republic Assault ship........:> unknown
    H-type Nubian yacht..........:> unknown
    Republic attack cruiser......:> unknown
    Theta-class T-2c shuttle.....:> unknown
    Trade Federation cruiser.....:> unknown
    Jedi Interceptor.............:> unknown
    Naboo star skiff.............:> unknown
    V-wing.......................:> unknown
    Belbullab-22 starfighter.....:> unknown
    Banking clan frigte..........:> unknown
    Star Destroyer...............:> 0
    CR90 corvette................:> 0
    Death Star...................:> 0
    Executor.....................:> 0
    Calamari Cruiser.............:> 0
    EF76 Nebulon-B escort frigate:> 0
    Millennium Falcon............:> 9
    Rebel transport..............:> 11
    Imperial shuttle.............:> 13
    Sentinel-class landing craft.:> 19
    Slave 1......................:> 19
    A-wing.......................:> 49
    X-wing.......................:> 59
    B-wing.......................:> 65
    Y-wing.......................:> 74
    TIE Advanced x1..............:> 79
    arc-170......................:> 83
    _____________________________________________________

## Testing
There are a couple of unit tests to ensure all methods work properly. 
To check the results you can run them on visual studio or, with visual studio code, just run: 

    dotnet test .\tests\ResupplyCalculator.Tests\ResupplyCalculator.Tests.csproj
