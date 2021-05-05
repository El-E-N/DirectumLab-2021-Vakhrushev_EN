import {IRootState} from '../../store/types';
import {roomSelector} from '../../store/room/room-selectors';
import {connect} from 'react-redux';
import MenuView, {IMenuProps} from './menu-view';
import {withRouter} from 'react-router-dom';
import {compose} from 'redux';
import * as React from 'react';
import {userSelector} from '../../store/user/user-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const user = userSelector(state);
  return {
    room,
    user,
  };
};

export default compose<React.ComponentClass<IMenuProps>>(withRouter, connect(mapStateToProps))(MenuView);
