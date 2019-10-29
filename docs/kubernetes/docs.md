
kubectl create secret docker-registry aws-ecr \
  --docker-server=SERVER \
  --docker-username=USER \
  --docker-password=PASSWORD \

# Secret configuration is in 64 encoding 
echo -n xxxx | base64
  

## Cron Jobs

https://crontab.guru/

 To run a cron job at every minute, the format should be like below.

* * * * * <command-to-execute>
For example if the time is 10:00, the next job will run at 10:01, 10:02, 10:03 and so on.

2. To run cron job at every 5th minute, add the following in your crontab file.

*/5 * * * * <command-to-execute>
For example if the time is 10:00, the next job will run at 10:05, 10:10, 10:15 and so on.

3. To run a cron job at every quarter hour (i.e every 15th minute), add this:

*/15 * * * * <command-to-execute>
For example if the time is 10:00, the next job will run at 10:15, 10:30, 10:45 and so on.

4. To run a cron job every hour at minute 30:

30 * * * * <command-to-execute>
For example if the time is 10:00, the next job will run at 10:30, 11:30, 12:30 and so on.

5. You can also define multiple time intervals separated by commas. For example, the following cron job will run three times every hour, at minute 0, 5 and 10:

0,5,10 * * * * <command-to-execute>
6. Run a cron job every half hour i.e at every 30th minute:

*/30 * * * * <command-to-execute>
For example if the time is now 10:00, the next job will run at 10:30, 11:00, 11:30 and so on.

7. Run a job every hour (at minute 0):

0 * * * * <command-to-execute>
For example if the time is now 10:00, the next job will run at 11:00, 12:00, 12:00 and so on.

8. Run a job every 2 hours:

0 */2 * * * <command-to-execute>
For example if the time is now 10:00, the next job will run at 12:00.

9. Run a job every day (It will run at 00:00):

0 0 * * * <command-to-execute>
10. Run a job every day at 3am:

0 3 * * * <command-to-execute>
11. Run a job every Sunday:

0 0 * * SUN <command-to-execute>
Or,

0 0 * * 0 <command-to-execute>
It will run at exactly at 00:00 on Sunday.

12. Run a job on every day-of-week from Monday through Friday i.e every weekday:

0 0 * * 1-5 <command-to-execute>
The job will start at 00:00.

13. Run a job every month (i.e at 00:00 on day-of-month 1):

0 0 1 * * <command-to-execute>
14. Run a job at 16:15 on day-of-month 1:

15 16 1 * * <command-to-execute>
15. Run a job at every quarter i.e on day-of-month 1 in every 3rd month:

0 0 1 */3 * <command-to-execute>
16. Run a job on a specific month at a specific time:

5 0 * 4 * <command-to-execute>
The job will start at 00:05 in April.

17. Run a job every 6 months:

0 0 1 */6 * <command-to-execute>
This cron job will start at 00:00 on day-of-month 1 in every 6th month.

18. Run a job every year:

0 0 1 1 * <command-to-execute>