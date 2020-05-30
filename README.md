## Thoughts & Mentions

Please find the solution I have produced within the confines the context and requirements given in the original readme.md (now spec.md).

I find these kind of tests particularly difficult when it comes to the point about "feel comfortable putting into production or 'production ready'", as I tend to find software development is very context specific.

There is a great number of solutions to any particular task, and I find without the greater context of who the solution is for, how they are going to use it, what impact it has on the business, and a variety of other parameters I makes it hard to choose the right solution as we are always balancing basic software principles that counter act like SOLID, K.I.S.S, and YAGNI, etc, the needs / requirements from business and general software properties likes robustness and stability.

Just saying, the code I would put into production for a prototype A/B test, an business critical system, and desperately needed internal efficiency tool would be vastly different. I do believe in constant improvement and growth both personally and software wise, so refactoring happens alot :P

Moving on to the solution:

## Assumptions -

I decided to make alot more assumptions rather than ask questions since I am doing this over the weekend, have been given a timeboxed 2 hours, so didn't want to do some pre-planning -> ask questions -> cheat time since already all planned :P

File formats are based upon file type not provider. If based upon provider as well the naming convention and way they are chosen should be updated.

Extra properties in files aren't currently needed. (and because theres no storage theres nothing i can do anyway)

Files won't be too large, if files get into gigabyte or larger size, the application will probably explode.

Since we a loading local files/printing to console it was hard to identify how they program would be used, thus things like exception handling, file parsing (& error handling invalid files), and logging haven't been handled yet.

Figured exchange rate is more of a temporary store in config and would be exchanged out for a proper service asap but theres alot of unknowns

## Things missing / still TODO

a code review :P

finalise tests - I haven't really covered much of the core functionality yet with tests however since we are using alot of IO (files/console), it is hard to put unit tests around those. I was potentially looking at refactoring out the file load logic from parsing logic so could test the parsing logic. This would led to problems on file size even more as couldn't do file stream for csv.

based upon the above, probably a bit of refactoring since alot of the system uses primative IO stuff it makes it harder to test, but was also trying to balance simplicity / and not over engineer the solution. Cause honestly if its really a production ready solution that prints to console only, it probably doesn't deserve too much time invested. Getting that balance right without context is hard :(

exception and error handling (like at all, currently just throws up).

logging utilise ILogger to actually log into something