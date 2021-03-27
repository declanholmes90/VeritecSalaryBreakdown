Considerations
-----------------------------

- Because the formulae for calculating deductions are quit simple an arithmetic based, I've decided to have formulae passed as a func parameter to the DeductableDefault class,
rather than creating a seperate concrete class for each. Doing it this way makes adding/removing or modifying deductions simple as they're all contained in a single place (Global Collection).

- Similarly to the above, Periods can be added/removed simply in the GlobalCollection static class.

-----------------------------
Notes
-----------------------------
 
 - It appears there may be an error in the example provided to me, the output value for Income Tax seems to have the floor function applied to it rather than ceiling
