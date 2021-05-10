import * as playerApi from '../../api/player-api';
import {updateUser as updateStoreUser} from './user-action-creators';
import {Dispatch} from 'redux';
import {IPlayer} from '../types';

export const updateUser = (name: string | null): any => {
  return async (dispatch: Dispatch): Promise<IPlayer | null> => {
    const user = name ? await playerApi.createPlayerRequest(name) : null;
    dispatch(updateStoreUser(user));
    return user;
  };
};
