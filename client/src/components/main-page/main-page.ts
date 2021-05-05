import {IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const user = userSelector(state);
  return {
    room,
    user
  };
};

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps))(MainPageView);
