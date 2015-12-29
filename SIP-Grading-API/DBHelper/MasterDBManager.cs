/*Using it*/
ArrayList r = GetJournalBy(new string[,] {
  {"TripID","=","1"},
  {"UserName","=","John"}
});

/*DB Manager Part*/
public static ArrayList GetJournalBy(string[,] restrictions)
{
    //string[x,0] - ColName
    //string[x,1] - Operator
    //string[x,2] - Value
    DatabaseSelectQuery dbListOfJournal = new DatabaseSelectQuery("Journal");

    for (int i = 0; i < restrictions.GetLength(0); i++)
    {
        dbListOfJournal.AddRestriction(restrictions[i, 0], restrictions[i, 1], restrictions[i, 2]);

    }

    SqlDataReader t = dbListOfJournal.RunQuery();
    ArrayList ret = new ArrayList();
    while (t.Read())
    {
        Journal j = new Journal();
        j.JournalID = (int)t["JournalID"];
        j.TripID = (int)t["TripID"];
        j.Time = (int)t["Time"];
        j.JournalContent = (string)t["JournalContent"];
        ret.Add(j);
    }
    return ret;
}

public static ArrayList GetJournalBy(string[,] restrictions, string opend)
{
    //string[0,0] - ColName
    //string[0,1] - Operator
    //string[0,2] - Value
    DatabaseSelectQuery dbListOfJournal = new DatabaseSelectQuery("Journal");

    for (int i = 0; i < restrictions.GetLength(0); i++)
    {
        dbListOfJournal.AddRestriction(restrictions[i, 0], restrictions[i, 1], restrictions[i, 2]);

    }

    dbListOfJournal.AddOpend(opend);

    SqlDataReader t = dbListOfJournal.RunQuery();
    ArrayList ret = new ArrayList();
    while (t.Read())
    {
        Journal j = new Journal();
        j.JournalID = (int)t["JournalID"];
        j.TripID = (int)t["TripID"];
        j.Time = (int)t["Time"];
        j.JournalContent = (string)t["JournalContent"];
        ret.Add(j);
    }
    return ret;
}

public static ArrayList GetAllJournalByTripID(int tripID)
{
    return GetJournalBy(new string[,] {{"TripID","=",tripID.ToString()}} , "ORDER BY Time DESC");
}
