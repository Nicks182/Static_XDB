# Disclaimer
This app contains a lot of experimental ideas and concepts like how I'm trying to generate HTML. You will see weird and even stupid stuff, but hopefully you'll see something interesting as well. I needed an actual project to try and get a better idea of what can work and what doesn't so I decided to make this little scripting tool. This is also the first time I've used Photino.net.

That said, the main function of the app, which is to turn a DB into scripts or turn scripts into a DB, does work... although there might still be quite a few bugs. 

Make Backups!


# Functionality
There is a help section on each screen to help you through the process, but here is a brief description.

## Scripting
The main purpose is to make it easier for a MSSQL DB to be put into git including the data in the DB. Static-XDB will create a separate script file for everything in your DB. This means each table, Procedure, View, ect will have its own stand alone text/.sql file. The same goes for data and each record will have its own stand alone file with an insert statement in it and nothing else. This makes it much easier to create branches of your project and have multiple people work on the same project as merges are now also easier.

Because we are just working with text/.sql files, we can easily put this into GIT. You can now clone the repository and use the app to run Push to DB to create the DB from the files you just cloned.

You can then switch to a different branch and again use the app to run Push to DB then have your DB in sync with your current GIT branch.

This way you can easily and fairly quickly switch between versions of your DB without needing to create multiple DBs or containers. This is really helpful on less powerful machines.

## Ignore
You can mark objects to be ignored by Static-XDB. This means that when you turn your DB into script files, the app will ignore any object you marked as such. This is most useful when you don't want to script all the data in your DB. Maybe you have some lookup tables that you want to script, but nothing else. In that case add all the tables you don't want to be scripted to the Ignore List.

## ViewDiff
The app can also show you the differences between what's in your DB compared to what is in your files. This allows you to see what changes were made in the DB BEFORE scripting those changes and overriding all the existing scripts.

You can do this with objects like procedures, views, tables, ect, and also data. You will be able to see which records have changes on a per table basis, but the app will only show rows that have changes and not ALL rows in the table.

# Youtube Demo
In the video below I already have a project setup in the app and it’s showing that the server and DB I’m looking at is online.

I then Push to Files and ‘convert’ the entire DB into .sql files. This means I now have a ‘snapshot’ of what the DB looks like at that point in time.

I then make some changes to a stored proc and data which the app can then highlight by comparing what is in the DB to what is in the files.

I then Push to DB and revert the whole DB back to the state it was in before I made any changes.

[![Youtube Demo](https://img.youtube.com/vi/JsDsdqv3A14/hqdefault.jpg)](https://www.youtube.com/watch?v=JsDsdqv3A14)
