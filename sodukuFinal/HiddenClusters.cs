using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class HiddenClusters
    {

        public bool FindHiddenClusters(Board game_board)
        {
            for (int i = 0; i < 7; i++)
            {
                if (!HiddenClusterShell(game_board, i))
                {
                    return false;
                }
            }
            return true;
        }
        public bool HiddenClusterShell(Board game_board, int cluster_size)
        {

            int side_size = game_board.getSize();
            for (int i = 0; i < side_size; i++)
            {
                if (!HiddenCluster(game_board.GetRow(i), game_board, cluster_size))
                {
                    return false;
                }
                if (!HiddenCluster(game_board.GetCol(i), game_board, cluster_size))
                {
                    return false;
                }
            }
            int square_size = (int)Math.Sqrt(side_size);
            for (int x = 0; x < side_size; x += square_size)
            {
                for (int y = 0; y < side_size; y += square_size)
                {
                    if (!HiddenCluster(game_board.GetSquare(x, y), game_board, cluster_size))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        

        public bool HiddenCluster(List<int[]> cell_group, Board game_board, int cluster_size)
        {
            int[] place = new int[2];
            int[] compared_place = new int[2];
            int amount_with_equal_cluster;
            for (int i = 0; i < cell_group.Count; i++)
            {
                place[0] = cell_group[i][0];
                place[1] = cell_group[i][1];
                if (game_board.GetCell(place[0], place[1]).get_amount_possible() == cluster_size)
                {
                    amount_with_equal_cluster = 1;
                    for (int j = i + 1; j < cell_group.Count; j++)
                    {
                        compared_place[0] = cell_group[j][0];
                        compared_place[1] = cell_group[j][1];
                        if (game_board.GetCell(compared_place[0], compared_place[1]).get_amount_possible() == cluster_size)
                        {
                            if (IsSameList(game_board.GetCell(compared_place[0], compared_place[1]).get_possible_nums(), game_board.GetCell(place[0], place[1]).get_possible_nums())) 
                            {
                                amount_with_equal_cluster++;
                            }
                        }
                    }
                    if (amount_with_equal_cluster == cluster_size)
                    {
                        if (!FoundCluster(game_board, game_board.GetCell(place[0], place[1]).get_possible_nums(), cell_group, cluster_size))
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
        public bool FoundCluster(Board game_board, List<int> numbers_to_elimanate, List<int[]> cell_group, int cluster_size)
        {
            int[] place = new int[2];
            Solver number_found_service = new Solver();
            List<int> numbers_to_elimante_copy = new List<int>(numbers_to_elimanate);
            foreach (int number_to_elimanate in numbers_to_elimante_copy)
            {
                for (int i = 0; i < cell_group.Count; i++)
                {
                    place[0] = cell_group[i][0];
                    place[1] = cell_group[i][1];
                    bool same_list_flag = IsSameList(game_board.GetCell(place[0], place[1]).get_possible_nums(), numbers_to_elimanate);
                    if (game_board.GetCell(place[0], place[1]).get_amount_possible() != cluster_size)// || !same_list_flag)
                    {
                        game_board.GetCell(place[0], place[1]).remove_possible_nums(number_to_elimanate);
                        if (game_board.GetCell(place[0], place[1]).get_amount_possible() == 1)
                        {
                            if (!number_found_service.number_found(game_board, place[0], place[1]))
                            {
                                return false;
                            }
                        }

                    }
                }
            }
            return true;
        }

        public bool IsSameList(List<int> l1, List<int> l2)
        {
            foreach (int number in l1)
            {
                if (!l2.Contains(number))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
