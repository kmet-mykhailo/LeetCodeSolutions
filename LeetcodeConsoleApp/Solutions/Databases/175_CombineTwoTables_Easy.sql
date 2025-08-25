-- https://leetcode.com/problems/combine-two-tables/description/

select P.firstName, P.lastName, A.city, A.state from Person P
left join [Address] A ON A.personId = P.personId