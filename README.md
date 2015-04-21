# PollApp
Windows Application for offline polling system. 

The application provides an interface for Admin and voters. The Admin can upload voters and contestants list as CSV and can view the statistics of the voting. Each voter is displayed the list of contestants for each post and he can vote only once.

#### Features
- For storing data, text files are being used. These files are portable and are useful for keeping records.
- Design of the application is made dynamic using design sheets. This allows the user to upload contestant list of large size.
- There can be any number of posts for voting.

####Installation
For installing, run the setup in Windows OS (version 7 or greater).

#### Usage

###### Logging in
The username and password for Admin are "admin". Currently, the credentials be changed through the application. Please refer [contributors section](#for-changing-login-credentials) for changing them if you're a developer. The login system identifies between voter and the admin.

###### CSV
Voter list and contestant list must uploaded in .csv format. The voter list must contain two columns containing the username and password. The contestant list should contain the posts in the first row and the respective contestants in each column.

###### Admin Panel
Throught the admin panel, admin can see the results for each post in the form of charts. He can reset votes at any point of time.

#### For contributors

The code can be run using Visual Studio IDE (version 2010 or greater). For modifying the setup solution Flexera Software is used.

##### For changing Login credentials
The login credentials can be changed manually in [Form4.vb file](https://github.com/ellore/PollApp/blob/8f279df7065460309dc4c7294fcca8157829a426/PollApp/PollApp/Form4.vb#L4).
