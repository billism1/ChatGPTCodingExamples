> Is there a better preforming Postgres SQL query to get the same result as the following Postgres SQL query?
>
>select count(t1.\*)
>
>from table1 t1
>
>left outer join table2 t2
>
>on t1.casenumber=t2.casenumber
>
>and t1.partnumber=t2.partnumber
>
>where t2.id is null

---

The query you provided seems to be efficiently counting the number of records in the "table1" table that have no matching records in the "table2" table based on the "casenumber" and "partnumber" columns.

One alternative to this query could be to use the "EXISTS" operator instead of a left outer join, like this:

sql

```sql
SELECT 
  COUNT(*)
FROM table1 t1
WHERE NOT EXISTS (
  SELECT 1
  FROM table2 t2
  WHERE t2.casenumber = t1.casenumber
    AND t2.partnumber = t1.partnumber
);
```

The `EXISTS` operator returns `TRUE` if the subquery returns at least one row, and `FALSE` otherwise. In this case, we're checking if there's no matching record in the "table2" table, so we use the `NOT` operator to reverse the result of the `EXISTS` operator.

Both of these queries should perform similarly, but the second one might be slightly more performant in some cases, as it doesn't need to do a full join. However, the actual performance difference will depend on factors such as the size of the tables, the distribution of data, the presence of indexes, etc. To determine which one is faster for your specific use case, you would need to test both queries and compare their performance using metrics like execution time and memory usage.

---