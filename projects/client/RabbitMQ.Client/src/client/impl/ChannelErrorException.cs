// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 1.1.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (C) 2007-2011 VMware, Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v1.1:
//
//---------------------------------------------------------------------------
//  The contents of this file are subject to the Mozilla Public License
//  Version 1.1 (the "License"); you may not use this file except in
//  compliance with the License. You may obtain a copy of the License
//  at http://www.mozilla.org/MPL/
//
//  Software distributed under the License is distributed on an "AS IS"
//  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
//  the License for the specific language governing rights and
//  limitations under the License.
//
//  The Original Code is RabbitMQ.
//
//  The Initial Developer of the Original Code is VMware, Inc.
//  Copyright (c) 2007-2011 VMware, Inc.  All rights reserved.
//---------------------------------------------------------------------------

using System;

// We use spec version 0-9 for common constants such as frame types,
// error codes, and the frame end byte, since they don't vary *within
// the versions we support*. Obviously we may need to revisit this if
// that ever changes.
using CommonFraming = RabbitMQ.Client.Framing.v0_9;

namespace RabbitMQ.Client.Impl
{
    /// <summary> Thrown when the server sends a frame along a channel
    /// that we do not currently have a Session entry in our
    /// SessionManager for. </summary>
    public class ChannelErrorException: HardProtocolException
    {
        private int m_channel;

        ///<summary>The channel number concerned.</summary>
        public int Channel { get { return m_channel; } }

        public ChannelErrorException(int channel)
            : base(string.Format("Frame received for invalid channel {0}", channel))
        {
            m_channel = channel;
        }

        public override ushort ReplyCode { get { return CommonFraming.Constants.ChannelError; } }
    }
}
