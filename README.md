# android_background
Android Background service
This uses the new jobscheduler to perform tasks every 15 minutes. This is usefull to do background work as the new Android OS 26+ places restrictions on regular background services, but not on those scheduled through the job scheduler.
Use this for syncing, or doing some other work on regular intervals.
