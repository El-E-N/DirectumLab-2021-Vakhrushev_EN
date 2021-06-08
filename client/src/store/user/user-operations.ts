import * as playerApi from '../../api/player-api';
import {IUserAction, updateUser as updateStoreUser} from './user-action-creators';
import {Dispatch} from 'redux';
import authService from '../../services/auth-service';

export const updateUser = (name: string | null): (dispatch: Dispatch) => Promise<IUserAction> => {
  return async (dispatch: Dispatch): Promise<IUserAction> => {
    const user = name ? await playerApi.createPlayerRequest(name) : null;

    authService.set(user !== null ? user.token : '');

    return dispatch(updateStoreUser(user));
  };
};
