using System;

namespace SupportCases
{
    enum PriorityLevel
    {
        Critical,
        Important,
        Medium,
        Low
    }

    struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    class Program
    {
        static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            Quick3Sort(tickets);
            Print(tickets);
            Console.Read();
        }

        static void Quick3Sort(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                for (int j = i + 1; j < tickets.Length; j++)
                {
                    if (Compara(tickets[i], tickets[j]))
                    {
                        SupportTicket temp = tickets[i];
                        tickets[i] = tickets[j];
                        tickets[j] = temp;
                    }
                }
            }
        }

        private static bool Compara(SupportTicket a, SupportTicket b)
        {
            bool result = false;

            if (a.Priority > b.Priority)
                {
                    result = true;
                    return result;
                }

            return result;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            return priority.ToLower().Trim() switch
            {
                "critical" => PriorityLevel.Critical,
                "important" => PriorityLevel.Important,
                "medium" => PriorityLevel.Medium,
                _ => PriorityLevel.Low,
            };
        }
    }
}
