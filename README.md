IntradayPowerPositionReport

Presumptions/Notes

Configuration is in appsettings.json within the IntradayPowerPositionReport.WorkerService project.

You'll need to update the appsettings.json with the path you'd like. THere is an expectation the path to where the file is saved is already valid.

If file exists, file generation fails, logged (currently logged to console but can be anywhere, log file etc..), but process keeps polling.

If the request for data takes longer than the polling length, a timeout exception is thrown to avoid more than one data extract and file creation being is flight at the same time.

Filename datefomat and underlying date data is UTC

Filename date format is yyyyMMdd_HHmm

I presume the ordering of the data from your dll is always correct, so no ordering in my code

To get this running with .NET 5, the service is of WorkerService project type with .UseWindowsService() set in program.cs 

Right click IntradayPowerPositionReport.WorkerService, publish, navigate to IntradayPowerPositionReport.WorkerService.exe and execute in command line (double click). You can also intall as a windows service if you really want to.

I have implemented dependency injection, which maybe overkill, but in theory means different datasources and export types can be plugged in (extended) without pulling apart the existing core logic and tests.

It would help if your supplied dll included an interface of the of the main class for test mocking and dependency injection code.

I left it running for 10 minutes as part of my tests to confirm 10 files were created each minute with expected filenames. I haven't tested larger intervals
