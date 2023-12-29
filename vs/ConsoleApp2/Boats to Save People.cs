Solution sol = new Solution();
Console.WriteLine(sol.NumRescueBoats([5,5,5,5,5], 5));

public class Solution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        int totalBoats = 0;
        int[] heavy = new int[people.Length];
        int[] light = new int[people.Length];
        int heavyIndex = 0;
        int lightIndex = 0;
        foreach (int person in people) {
            if (person > limit / 2) { heavy[heavyIndex++] = person; }
            else { light[lightIndex++] = person; }
        }
        int[] heavyFull = new int[heavyIndex];
        int[] lightFull = new int[lightIndex];
        Array.Copy(heavy, heavyFull, heavyIndex);
        Array.Copy(light, lightFull, lightIndex);
        Array.Sort<int>(heavyFull);
        Array.Sort<int>(lightFull, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
        int nextHeavyIndex = 0;

        for (int i = 0; i < lightFull.Length; i++) {
            if (nextHeavyIndex < heavyFull.Length)
            {
                if (lightFull[i] + heavyFull[nextHeavyIndex] <= limit)
                {
                    nextHeavyIndex++;
                    totalBoats++;
                }
                else
                {
                    i++;
                    totalBoats++;
                }
            } else
            {
                totalBoats += 1+((lightFull.Length - i - 1) / 2);
                break;
            }
        }
        if (nextHeavyIndex < heavyFull.Length)
        {
            totalBoats += heavyFull.Length - nextHeavyIndex;
        }



        //Array.Sort<int>(people, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));  // Array.Sort(people); Array.Reverse(people);


        /*
        for (int i=0; i < people.Length; i++)
        {
            if (people[i] > 0)
            {
                bool foundJ = false;
                for (int j = i + 1; j < people.Length; j++)
                {
                    if (people[j] > 0)
                    {
                        if (people[i] + people[j] <= limit)
                        {
                            totalBoats++;
                            people[j] = -1;
                            foundJ = true;
                            break;
                        }
                    }
                }
                if (!foundJ)
                {
                    totalBoats++;
                }
            }
        }
        */
        return totalBoats;
    }
}