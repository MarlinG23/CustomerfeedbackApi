2 Seperate projects created
----------------------------
1. .net 8 RESTFUL web api in visual studio as backend & flutter_customerfeedback_api  as Front in VS Code
2. DB locally created using MS SQL - 2 tables created (dbo.UserInfo & dbo.users)

Steps to Run app
-----------------
 1. Launch CustomerfeedbackApi in visual studio
 2. Launch flutter_customerfeedback in vs code (frontend is dependant on CustomerfeedbackApi)
- CRUD created for full interaction with DB/swagger and flutter app. 
- Login functionality currently works using swagger / Front end changes left aside 
- Code first approach
- Interaction with swagger "insert/delete/search/update" all working
- Authentication for login screen created but login screen not finished [time constraint due to current projects]
- Linq interaction with db working perfect
- Created flutter front end app
- Customerfeedback screen created
- serch user created
- add feeed with name, email, customerfeedback
- Automated email working using system.net.mail, automation works as expected once customer feedback is submitted from front end

Below are a few challenges faced:
----------------------------------
- email authentication created but sendgrid gives an error after signing up and trying to navigate the site(multiple email signups all get error)
- OneSignal email auth created - few issues, current app gives issues, but on seperate app emails are being sent[figure out why]
- Personal machine is an i5, so machine boms out connecting to firebase features/onesignal as well
- outstanding items = Login frontEnd
