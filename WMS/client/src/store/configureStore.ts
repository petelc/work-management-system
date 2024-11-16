import { configureStore } from '@reduxjs/toolkit';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import { requestSlice } from '../pages/request/requestSlice';
import { accountSlice } from '../pages/account/accountSlice';
import { dashboardSlice } from '../pages/dashboard/dashboardSlice';

export const store = configureStore({
  reducer: {
    request: requestSlice.reducer,
    account: accountSlice.reducer,
    dashboard: dashboardSlice.reducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
