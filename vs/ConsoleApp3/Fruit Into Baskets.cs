Solution sol = new Solution();

Console.WriteLine(sol.TotalFruit([1,2,1,2,1]));

public class Tree
{
    public int count = 1;
    public int fruitA = -1;
    public int fruitB = -1;
    public Tree() { }
}
public class Solution
{

    public int TotalFruit(int[] fruits)
    {

        int count = 0;

        List<Tree> treeList = new List<Tree> { };
        List<Tree> activeTrees = new List<Tree> { };

        for (int i = 0; i < fruits.Length; i++)
        {
            Tree tree1 = new Tree();
            tree1.fruitA = fruits[i];
            treeList.Add(tree1);
            List<Tree> toDelete = new List<Tree> { };

            foreach (Tree tree in activeTrees)
            { // Moving inactive trees to delete
                if (tree.fruitA != -1 && tree.fruitB != -1 && tree.fruitA != fruits[i] && tree.fruitB != fruits[i])
                {
                    toDelete.Add(tree);
                }
            }

            foreach (Tree tree in toDelete)
            { // Deletes inactive trees
                activeTrees.Remove(tree);
            }
            toDelete.Clear();

            foreach (Tree tree in activeTrees)
            { // starting a chain
                if (tree.fruitA != fruits[i])
                {
                    tree.fruitB = fruits[i];
                }
            }

            foreach (Tree tree in activeTrees) // culls activeTrees
            {
                foreach (Tree treeX in activeTrees)
                {
                    if (tree.count > treeX.count)
                    {
                        if ((tree.fruitA == treeX.fruitA && tree.fruitB == treeX.fruitB) || (tree.fruitA == treeX.fruitB && tree.fruitB == treeX.fruitA))
                        {
                            toDelete.Add(treeX);
                        }
                    }
                }
            }
            foreach (Tree tree in toDelete)
            { // Deletes inactive trees
                activeTrees.Remove(tree);
            }
            toDelete.Clear();


            foreach (Tree tree in activeTrees)
            {
                if (tree.fruitA == fruits[i])
                {
                    tree.count++;
                }
                else if (tree.fruitB == fruits[i])
                {
                    tree.count++;
                }
                else if (tree.fruitB < 0)
                {
                    tree.fruitB = fruits[i];
                    tree.count++;
                }

            }

            activeTrees.Add(tree1);


        }

        foreach (Tree tree in treeList)
        {
            if (tree.count > count)
            {
                count = tree.count;
            }
        }


        return count;
    }
}