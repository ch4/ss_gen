# ss_gen

![Screenshot](/img/ss_gen_example.png?raw=true "Screenshot")

ss_gen is a quick and dirty WinForm app that automates the BofA ShopSafe and Citi Virtual Account Number generation process. Simply paste in your session ID from your cookies, hit the go button for as many numbers as you require, and a nicely-formatted csv is created. It's handy if you want to generate a ton of numbers to print out for later use. 

I made this because the Flash app that they use is really clunky and slow (it takes more than something like 7 clicks to generate a card with a custom expiry and dollar limit!) and doesn't work on mobile.

Right now, there are 2 hardcoded cards that are supported:

  - BofA BankAmericard Cash Rewards Card
  - Citi Double Cash Card
  
If anyone wants to use it on a different card, it should be pretty simple to modify for your card...
