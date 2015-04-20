# PollApp
Windows Application for offline polling system

#Installation Requirements
Windows Platform for running the setup
Visual studio platform is required for using the code
Flexera software is required for development purpose

#usage
-Username for Admin is "admin" and password is also "admin". The username and password are hardcoded into
 Program and can be changed from 'Form4.vb' file.
-Voter's List must uploaded in .csv format. It must contain two columns first containing the username and
 the second password.
-Candidate's list must also be uploaded in .csv format. It can conatin finitely many columns with each of
 them having their first row to be the name of the post. Each column can contain finitely many rows including
 zero each representing a candidates name.
-Based on the username user logs into admin system or voting system.
-Admin can see the results in the form of charts.
-Admin can reset votes at any point of time.
-There are "next", "back" buttons to move across the tabs.

#Main Features
-Design of the application is made dynamic using design sheets.
-For storing data text files are being used.
-Any number of candidates can apply for any post.
-There can be any number of posts for voting.

#Bugs and drawbacks
-There is no confirmation during resetting votes.
-Password is not hidden
-There is room for adding images but not implemented  