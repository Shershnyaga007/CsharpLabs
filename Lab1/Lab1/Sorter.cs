namespace Lab1
{
    public class Sorter
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray =  array.Clone() as int[];
        
            while (true)
            {
                var isSorted = true;
                for (var i = 0; i < sortedArray.Length - 1; i++)
                {
                    if (sortedArray[i] <= sortedArray[i + 1]) continue;
                    
                    isSorted = false;
                    Swap(sortedArray, i);
                }
            
                if (isSorted)
                {
                    break;
                }
            }

            return sortedArray;
        }

        private static void Swap(int[] array, int index)
        {
            (array[index], array[index + 1]) = (array[index + 1], array[index]);
        }
    }
}