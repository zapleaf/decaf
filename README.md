## decaf Application
This a C# Blazor application that tracks YouTube channels.

For videos you can add notes, mark them as watched, and review basic analysis on views.
Channels can be organized into categories alowing you to lis vides from channels by those categories.

This application does not use an API. Almost every coporate application I have created over the last several years used an API and I wanted to review the advantages of not using one for this application.

## Blazor Layer
This is the admin UI with read and write methods. This is not published publicly. I only run this locally.

## Channel Update
This is an Azure Function that regularly calls the YouTube API to retrieve any new videos and update view stats.

## Standard Clean Architecture Application layers
This application uses the standard Clean Architecture layers. I based this off of the Clean Architecture I use at my current employer and what I have learned from tutorials like those from https://www.youtube.com/@PatrickGod.

### Application
Contains Commands and Query (CQRS), the Handlers, and the interfaces for the Services and Repositories. This layer uses AutoMapper and Mediatr.

### Domain
Contains the Entities, the Base Entity, and some extension classes.

### Infrastructure
Contains the Data (context, migrations, seeders, etc) classes, the Repositories, and Services.
