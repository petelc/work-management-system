import { useEffect } from 'react';
import { boardSelectors, fetchBoardsAsync } from '../pages/board/boardSlice';
import { useAppSelector, useAppDispatch } from '../store/hooks';

type BoardState = {
  boards: any;
  boardsLoaded: boolean;
  metaData: any;
};

export default function useBoards(): BoardState {
  const boards = useAppSelector(boardSelectors.selectAll);
  const { boardsLoaded, metaData } = useAppSelector((state) => state.board);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!boardsLoaded) dispatch(fetchBoardsAsync());
  }, [boardsLoaded, dispatch]);

  return {
    boards,
    boardsLoaded,
    metaData,
  };
}
