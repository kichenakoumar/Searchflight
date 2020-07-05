Searchfight: this application queries search engines and compares how many results they return.
For example refer below for the input:

Searchfight.exe .Net c# "Java script"
 
The output will be as follows:
.Net:
Google Search count: 0
Msn Search count: 79600000
Yahoo Search count: 0

C#:
Google Search count: 0
Msn Search count: 12800000
Yahoo Search count: 0

Java Script:
Google Search count: 0
Msn Search count: 124000000
Yahoo Search count: 0

Msnwinner: .Net
Msnwinner: C#
Msnwinner: Java Script

In order to enhace the application to increase the search engine-Please refer and add in the App.config
*The value is the comma seprated one which has the Search engine URl , Xpath selector for the search engine
   <appSettings>
      <add key="Google" value="http://www.google.com/search?q=,resultStats"/>
      <add key="Msn" value="http://www.bing.com/search?q=,sb_count"/>
      <add key="Yahoo" value="http://search.yahoo.com/search?p=,resultCount"/>
     </appSettings>
