# Selenium with SpecFlow Testing Framework #

### **Important:** First restore project dependencies. One approach to do this is just to build the project. ###

**NUnit** powers the tests. 

If no unit tests are shown in Visual Studio Test Explorer, there could be several reasons. One of the most likely is an inconsistency between the **Default Process Architecture in the Test Settings** and **Platform target architecure**. They should be equal - x64 or x86. To fix this set the architecture specified in the menu at **Test -> Test Settings -> Default Processor Architecture** with the value of the **Platform Target**. To verify the latter **Right click on the project -> Properties -> Build -> Platform target:**

The framework uses Selenium and SpecFlow with the following default settings:
* Driver - Chrome
* Timeout to wait for element - 5000 milliseconds
* Url - https://www.amazon.co.uk/
* Reports folder name - Reports
* Logs folder name - Logs

## In order to change some of the default settings open App.config file and change the value of the related key. ##
***

### Driver configuration ###
Browsers that can be used are:
* Chrome - with value **chrome**
* Firefox - with value **firefox**
* Edge  with value **edge**
*IE 1 - with value**ie**.

For example to the default driver is **chrome** and the configuration is:
```xml
    <add key="driver" value="chrome" />
```
In order to change the driver set the value for example to  **firefox**:
```xml
    <add key="driver" value="firefox" />
```
**Important:** It is quite possible using IE 11 to require some additional configurations. For more information please read [Required Configuration for IE 11.](https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver#required-configuration)

***
### Timeout configuration ###
The default timeout is 5000 milliseconds. 
```xml
<add key="timeout" value="5000" />
```
In order to change the timeout set the value for example to 10000.
```xml
<add key="timeout" value="10000" />
```
The same approach can be used for the other properties.
***

The folders **Reports** and **Logs** will be created (if they don't exist) at the level of the folder that contains the solution. For example:

D:\\

.......\SolutionContainer

..................\ Logs

..................\ Reports

..................\ TestingFrameworkProject
***