
This project is a web application that contains both front-end and back-end components. 
The front-end is built using the .NET 5.0 platform, while the front-end is built using Vue.js 3.2. 

The front-end contains an auto-complete web component that loads suggestions from the back-end. 
The data is stored in an SQLite database and is updated from the server every time the user changes the search term. 
The user interface of the web application allows users to enter a search term, 
and the auto-complete component will then display a list of suggestions based on the search term. 
These suggestions are retrieved in real-time from the back-end, which is connected to the SQLite database. 

Project structure
![image](https://user-images.githubusercontent.com/16181086/214821354-44369d5c-0ac5-4d4a-8e76-82982d3bc038.png)

Run/Debug
![image](https://user-images.githubusercontent.com/16181086/214823047-af7dc231-7761-49ef-a2fd-31e108b48304.png)



The web application also includes a caching mechanism to reduce latency and improve performance. This mechanism is implemented to cache similar search results, so that when a user performs a search that has been previously done, the web application can retrieve the results from the cache instead of querying the back-end and the database again. This helps to reduce the latency of the application and improve the overall user experience. The cache is updated every time the search term is changed by the user and new results are retrieved from the back-end.
![image](https://user-images.githubusercontent.com/16181086/214825226-f88ecb42-f816-4c8e-ac80-87e4b8dec2d2.png)
