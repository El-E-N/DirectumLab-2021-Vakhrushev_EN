import {history} from '../index';
import {RoutePath} from '../routes';

export const loadRoom = (id: string) => {
  history.push(`${RoutePath.INVITE}/${id}`);
};
