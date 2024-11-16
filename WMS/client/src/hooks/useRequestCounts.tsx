import { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../store/configureStore';
import {
  dashboardSelectors,
  fetchRequestCountsAsync,
} from '../pages/dashboard/dashboardSlice';

export default function useRequestCounts() {
  const requestCounts = useAppSelector(dashboardSelectors.selectAll);
  const { countsLoaded } = useAppSelector((state) => state.dashboard);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!countsLoaded) dispatch(fetchRequestCountsAsync());
  }, [countsLoaded, dispatch]);

  return {
    requestCounts,
    countsLoaded,
  };
}
