import {IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import UserView from './user-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';

const mapStateToProps = (state: IRootState) => {
  return {
    user: userSelector(state),
    room: roomSelector(state),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps))(UserView);
