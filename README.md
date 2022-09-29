# CMPG323Project3-33677727
The Web App developed for this project is meant to store information on IoT devices. The App allows you to store informaton on the Category of the Device (Name, Description and Date Created), on the Zone the Device is located in (Name, Description and Date Created) as well as information on the IoT Device itself (Name, Status, Is Active, Date Created, Category and Zone). The Web App makes use of a database hosted on Azure to store the information and the Web App is also hosted on Azure.

This Web App makes use of the MVC architecture pattern and uses Views, Models and Controllers. The Controller makes use of Repositories. A Generic Repository is used for all Database Context access operations. Each class is also given their own Repository which their controller uses to access the datbase indirectly.

## Using the Web App
To access the Web App hosted on Azure the following link can be used:
https://devicemanagementwebapp33677727.azurewebsites.net

<br/>![image](https://user-images.githubusercontent.com/83065167/193046327-e7b366fb-17d8-439d-b376-7d1cb4e62755.png)

To use the Web app you can Register your own account or use the provided Login credentials. Once you have logged in three new tabs will become avaliable to you, namely Zones, Categories and Devices. 

<br/>![image](https://user-images.githubusercontent.com/83065167/193046489-bb5d723b-6a0d-4eb7-aa31-43e6edc15dcb.png)

You can then Add, Edit, Delete and View Zones, Categories and Devices on the Web App. The Web App is quite user friendly and there should be little difficulty navigating to the different sections. Once you have added, edited or deleted all the Zones, Categories and Devices you want, you can then log out using the logout button on the menu tab.


<br/>![image](https://user-images.githubusercontent.com/83065167/193046724-4fccc45b-2aea-479f-b23b-8460a2f450a2.png)


## Security
To ensure that no credential are avaliable or present in the Project 3 repository, all the files that contain sensitive information or that may contain credentials have been added to the gitignore file. This was done after the repository was forked and before any work was done to ensure no credential are present in earlier commits of the project.

## Project Accesability
Because this project was forked from another reopsitory it was not possible to make the repositry private as all forked repositories must be public.
