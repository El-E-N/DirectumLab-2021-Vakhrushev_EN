import {IRootState} from '../../store/types';
import {IMatchParams} from '../main-page/main-page-view';
import {roomByIdSelector} from '../../store/room/room-selectors';
import {connect} from 'react-redux';
import MenuView, {IMenuProps} from './menu-view';
import {RouteComponentProps, withRouter} from 'react-router-dom';
import {compose} from 'redux';
import * as React from 'react';

const mapStateToProps = (state: IRootState, ownProps: RouteComponentProps<IMatchParams>) => {
  const room = roomByIdSelector(state, ownProps.match.params.id);
  return {
    room,
    user: state.user,
  };
};

export default compose<React.ComponentClass<IMenuProps>>(withRouter, connect(mapStateToProps))(MenuView);
