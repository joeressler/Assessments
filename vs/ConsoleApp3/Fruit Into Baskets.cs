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
                else
                {
                    toDelete.Add(tree);
                }
            }
            foreach (Tree tree in toDelete)
            {
                activeTrees.Remove(tree);
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