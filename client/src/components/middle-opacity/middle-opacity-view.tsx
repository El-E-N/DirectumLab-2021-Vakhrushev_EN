import * as React from 'react';
import { IRoom } from '../../store/types';
import './middle-opacity.css';

interface IProps {
  room: IRoom;
}

const MiddleOpacityView: React.FunctionComponent<IProps> = (props) => {
  return props.room.shownModal ? <div className="middle-opacity"/> : null;
};

export default MiddleOpacityView;
