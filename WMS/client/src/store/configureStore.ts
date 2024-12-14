import { configureStore } from '@reduxjs/toolkit';
// import { persistStore, persistReducer } from 'redux-persist';
//import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
// import storage from 'redux-persist/lib/storage';
//import { composeWithDevTools } from 'redux-devtools-extension';

import { requestSlice } from '../pages/request/requestSlice';
import { accountSlice } from '../pages/account/accountSlice';
import { dashboardSlice } from '../pages/dashboard/dashboardSlice';

// const rootReducer = combineReducers({
//   request: requestSlice.reducer,
//   account: accountSlice.reducer,
//   dashboard: dashboardSlice.reducer,
// });

// const persistConfig = {
//   key: 'root',
//   storage,
// };

//const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: {
    request: requestSlice.reducer,
    account: accountSlice.reducer,
    dashboard: dashboardSlice.reducer,
  },
});

//const persistor = persistStore(store);

//export { store, persistor };

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch; //

// export const useAppDispatch = () => useDispatch<AppDispatch>();
// export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
