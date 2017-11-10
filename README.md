# RazorGDI

Fast 2D draw in .Net WPF and WindowsForms
Special for http://habrahabr.ru under MIT license

 The best thing in this project - its realy fast, possible thousands FPS on not too big control (depends on your PC, and if you realy need it on your 60Hz LCD). 
 Another cool thing - you can draw on this controls under any thread, or few different threads, w/o UI thread syncronization (UI thread realy not used in backend library too).
 And... its simple to code and simple to use. Realy simple.

 Some discussions (basically russian language, but you can ask on english, its IT-site) 
 here: http://habrahabr.ru/post/164705/, 
 and continued here: http://habrahabr.ru/post/164885/

P.S. It is possible to port WinForms set to .Net Framework 2.0 via simple fix namespace usages.

07.01.2013
 Dedicated lock object RazorLock for locking to avoid resize/repaint race, added comments
 Checked 22364 as version 0.6 beta and added to downloads
 Special thanxs for habra-users
http://habrahabr.ru/users/alexanderzaytsev/, http://habrahabr.ru/users/sintez/, http://habrahabr.ru/users/nile1/

06.01.2013:
 Added WindowForms backend control and WF test application.
 Tuned and bugfixed library and WPF control and test application.
 Now, WPF and WinForms controls and test application is thread safe for resize etc.
