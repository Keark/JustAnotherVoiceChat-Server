﻿/*
 * File: NativeLibary.cs
 * Date: 21.2.2018,
 *
 * MIT License
 *
 * Copyright (c) 2018 JustAnotherVoiceChat
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Runtime.InteropServices;
using JustAnotherVoiceChat.Server.Wrapper.Delegates;
using JustAnotherVoiceChat.Server.Wrapper.Structs;

// ReSharper disable UnusedMember.Local
namespace JustAnotherVoiceChat.Server.Wrapper.Elements.Wrapper
{
    internal static class NativeLibary
    {

#if LINUX
        private const string JustAnotherVoiceChatLibrary = "libJustAnotherVoiceChat.Server.so";
#else
        private const string JustAnotherVoiceChatLibrary = "JustAnotherVoiceChat.Server.dll";
#endif

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_CreateServer(ushort port, string teamspeakServerId, ulong teamspeakChannelId, string teamspeakChannelPassword);

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_DestroyServer();

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_StartServer();
            
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_StopServer();
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        [return:MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_IsServerRunning();
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern int JV_GetNumberOfClients();
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern unsafe void JV_GetClientGameIds(ushort* list, int maxlength);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_RemoveClient(ushort handle);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_SetClientNickname(ushort handle, string nickname);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RemoveAllClients();

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_Set3DSettings(float distanceFactor, float rolloffFactor);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_IsClientConnected(ushort handle);
        
        /**
         * Events
         */

        // ClientConnected
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientConnectedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientConnectedCallback();
        
        // ClientConnected
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientConnectingCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientConnectingCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientConnectingCallback();

        // ClientRejected

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientRejectedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientRejectedCallback callback);

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientRejectedCallback();
        
        // ClientDisconnected
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientDisconnectedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientDisconnectedCallback();
        
        // ClientStartsTalking
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientTalkingChangedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientStatusCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientTalkingChangedCallback();
        
        // ClientSpeakersMuteChanged
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientSpeakersMuteChangedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientStatusCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientSpeakersMuteChangedCallback();
        
        // ClientMicrophoneMuteChanged
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterClientMicrophoneMuteChangedCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.ClientStatusCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterClientMicrophoneMuteChangedCallback();

        // LogMessage

        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_SetLogLevel(int logLevel);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_RegisterLogMessageCallback([MarshalAs(UnmanagedType.FunctionPtr)] NativeDelegates.LogMessageCallback callback);
        
        [DllImport(JustAnotherVoiceChatLibrary)]
        internal static extern void JV_UnregisterLogMessageCallback();
        
        /**
         * 3D Voice
         */

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_SetClientVoiceRange(ushort clientId, float voiceRange);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_SetClientPosition(ushort clientId, float x, float y, float z, float rotation);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_SetClientPositions(ClientPosition[] clientPositions, int length);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_SetRelativePositionForClient(ushort listenerId, ushort speakerId, float x, float y, float z);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_ResetRelativePositionForClient(ushort listenerId, ushort speakerId);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_ResetAllRelativePositions(ushort clientId);

        /**
         * Muting
         */

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_MuteClientForAll(ushort clientId, bool muted);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_IsClientMutedForAll(ushort clientId);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_MuteClientForClient(ushort speakerId, ushort listenerId, bool muted);

        [DllImport(JustAnotherVoiceChatLibrary)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool JV_IsClientMutedForClient(ushort speakerId, ushort listenerId);

    }
}
