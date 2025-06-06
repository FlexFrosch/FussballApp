using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballApp
{
    //class League
    //{
    //    public List<Team> Teams { get; set; } = new List<Team>();
    //    public List<Team> Table { get; set; } = new List<Team>();
    //    private bool IsInt;

    //    public League(List<Team> Teams, bool IsInternationial)
    //    {
    //        this.Teams = Teams;
    //        this.IsInt = IsInternationial;
    //    }

    //    public void CalculateTable()
    //    {
    //        Table.Clear();
    //        if (IsInt == true)
    //        {
    //            foreach (Team team in Teams)
    //            {
    //                if (Table.Count == 0)
    //                {
    //                    Table.Add(team);
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < Table.Count; i++)
    //                    {
    //                        if (team.PointsInt > Table[i].PointsInt)
    //                        {
    //                            Table.Insert(i, team);
    //                            i = Table.Count;
    //                        }
    //                        else if (team.PointsInt == Table[i].PointsInt)
    //                        {
    //                            if (team.GoalsInt >= Table[i].GoalsInt)
    //                            {
    //                                Table.Insert(i, team);
    //                            }
    //                            else
    //                            {
    //                                Table.Insert(i + 1, team);
    //                            }
    //                            i = Table.Count;
    //                        }
    //                        else if (i == Table.Count - 1)
    //                        {
    //                            Table.Add(team);
    //                            i = Table.Count;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            foreach (Team team in Teams)
    //            {
    //                if (Table.Count == 0)
    //                {
    //                    Table.Add(team);
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < Table.Count; i++)
    //                    {
    //                        if (team.PointsLeague > Table[i].PointsLeague)
    //                        {
    //                            Table.Insert(i, team);
    //                            i = Table.Count;
    //                        }
    //                        else if (team.PointsLeague == Table[i].PointsLeague)
    //                        {
    //                            if(team.GoalsLeague >= Table[i].GoalsLeague)
    //                            {
    //                                Table.Insert(i, team);
    //                            }
    //                            else
    //                            {
    //                                Table.Insert(i + 1, team);
    //                            }
    //                            i = Table.Count;
    //                        }
    //                        else if (i == Table.Count - 1)
    //                        {
    //                            Table.Add(team);
    //                            i = Table.Count;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}
