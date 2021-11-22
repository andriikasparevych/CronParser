# CronParser
Command line utility that parses the cron expression and outputs the result to the console.

Language: C#

Target platform: .NET 6.0
## How to build on Linux
1. Install the .NET 6.0 SDK.
  
    If you're running a clean Ubuntu 20.04 (e.g. in a docker container) use the following commands:

```
apt-get update
apt-get install sudo -y
apt-get install wget -y
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb 
sudo dpkg -i packages-microsoft-prod.deb 
apt-get update
sudo apt install apt-transport-https -y 
sudo apt install dotnet-sdk-6.0 -y -q
```

> The full instruction can be found at https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2104-

2. Clone this repo and navigate to the root folder (CronParser)
```
sudo apt-get install git -y
git clone https://github.com/andriikasparevych/CronParser.git
cd CronParser
```

3. Run `dotnet run "{argument_string}"` passing the argument string afterwards. This command will compile and run the project. E.g.

`dotnet run "*/15 0 1,15 * 1-5 /usr/bin/find"`

## Running tests
You can add more test cases to the Tests/CronParserTests.cs file and then execute them by running

`dotnet test`

## Notes
The input validation wasn't implemented due to time limits.
