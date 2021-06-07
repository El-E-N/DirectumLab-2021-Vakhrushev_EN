import * as playerApi from '../../api/player-api';
import {updateUser as updateStoreUser} from './user-action-creators';
import {Dispatch} from 'redux';
import authService from '../../services/auth-service';

export const updateUser = (name: string | null): any => {
  return async (dispatch: Dispatch) => {
    const user = name ? await playerApi.createPlayerRequest(name) : null;
    authService.set(user !== null ? user.id : '');
    return dispatch(updateStoreUser(user));
  };
};
