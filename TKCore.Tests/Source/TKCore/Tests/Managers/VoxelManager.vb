Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Mathematics
Imports OpenTK.Windowing.Common
Imports TKCore.Extra
Imports TKCore.Graphics
Public Class VoxelManager : Implements IDisposable
    Private Const InitialCapacity As Int32 = 1000000
    
    Private ReadOnly Context As GLContext
    Private Texture As GLTexture
    
    
    Private ReadOnly Voxels As List(Of Voxel)
    
    Private ReadOnly Program As GLProgram
    Private Matrices As Matrix4()       = Nothing
    Private Coordinates As Vector2()    = Nothing
    Private ShininessValues As Single() = Nothing
    Private AlwaysLitValues As Single() = Nothing
    
    Private ReadOnly MeshVertices As GLBuffer
    Private ReadOnly MeshIndices As GLBuffer
    Private ReadOnly MeshNormals As GLBuffer
    Private ReadOnly MeshTextureCoordinates As GLBuffer
    Private ReadOnly VoxelMesh As Mesh
    
    Private ReadOnly InstanceMatrices As GLBuffer
    Private ReadOnly InstanceAtlasCoordinates As GLBuffer
    Private ReadOnly InstanceShininess As GLBuffer
    Private ReadOnly InstanceAlwaysLit As GLBuffer
    
    Private ReadOnly LightPointers As LightPointer() = Nothing
    
    Public Sub New()
        Context = New GLContext()
        
        Texture = TextureLoader.FromFile("./Assets/Textures/DebugTexture.png", TextureUnit.Texture0)
        
        Context.Attach(Texture)
        
        Dim FragmentShader = New GLShader(IO.File.ReadAllBytes("./Assets/Shaders/NewShader/Fragment.glsl"), ShaderType.FragmentShader)
        Dim VertexShader   = New GLShader(IO.File.ReadAllBytes("./Assets/Shaders/NewShader/Vertex.glsl"), ShaderType.VertexShader)
        Program = New GLProgram(FragmentShader := FragmentShader, VertexShader := VertexShader)
        FragmentShader.Dispose()
        VertexShader.Dispose()
        
        Context.Attach(Program)
        
        Voxels = New List(Of Voxel)(InitialCapacity)
        Array.Resize(Matrices, InitialCapacity)
        Array.Resize(Coordinates, InitialCapacity)
        Array.Resize(ShininessValues, InitialCapacity)
        Array.Resize(AlwaysLitValues, InitialCapacity)
        
        MeshVertices = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim MeshVerticesAttribute As New GLBufferAttribute(0, 3, TKCore.Constants.ByteSize.Vector3, 0)
        MeshVertices.Add(MeshVerticesAttribute)
        
        Context.Attach(MeshVertices)
        
        MeshTextureCoordinates = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim MeshTextureCoordinatesAttribute As New GLBufferAttribute(1, 2, TKCore.Constants.ByteSize.Vector2, 0)
        MeshTextureCoordinates.Add(MeshTextureCoordinatesAttribute)
        
        Context.Attach(MeshTextureCoordinates)
        
        MeshNormals = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim MeshNormalsAttribute As New GLBufferAttribute(2, 3, TKCore.Constants.ByteSize.Vector3, 0)
        MeshNormals.Add(MeshNormalsAttribute)
        
        Context.Attach(MeshNormals)
        
        MeshIndices = New GLBuffer(BufferTarget.ElementArrayBuffer)
        
        Context.Attach(MeshIndices)
        
        VoxelMesh = New Mesh()
        MeshIndices.Upload(VoxelMesh.Indices, BufferUsageHint.StaticDraw)
        MeshVertices.Upload(VoxelMesh.Vertices, BufferUsageHint.StaticDraw)
        MeshNormals.Upload(VoxelMesh.Normals, BufferUsageHint.StaticDraw)
        MeshTextureCoordinates.Upload(VoxelMesh.TextureCoordinates, BufferUsageHint.StaticDraw)
        
        InstanceMatrices = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim InstanceMatricesAttributeA As New GLBufferAttribute(3, 4, TKCore.Constants.ByteSize.Matrix4, 00 * TKCore.Constants.ByteSize.Single, 1)
        Dim InstanceMatricesAttributeB As New GLBufferAttribute(4, 4, TKCore.Constants.ByteSize.Matrix4, 04 * TKCore.Constants.ByteSize.Single, 1)
        Dim InstanceMatricesAttributeC As New GLBufferAttribute(5, 4, TKCore.Constants.ByteSize.Matrix4, 08 * TKCore.Constants.ByteSize.Single, 1)
        Dim InstanceMatricesAttributeD As New GLBufferAttribute(6, 4, TKCore.Constants.ByteSize.Matrix4, 12 * TKCore.Constants.ByteSize.Single, 1)
        InstanceMatrices.Add(InstanceMatricesAttributeA)
        InstanceMatrices.Add(InstanceMatricesAttributeB)
        InstanceMatrices.Add(InstanceMatricesAttributeC)
        InstanceMatrices.Add(InstanceMatricesAttributeD)
        
        Context.Attach(InstanceMatrices)
        
        InstanceAtlasCoordinates = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim InstanceAtlasCoordinatesAttribute As New GLBufferAttribute(7, 2, TKCore.Constants.ByteSize.Vector2, 0, 1)
        InstanceAtlasCoordinates.Add(InstanceAtlasCoordinatesAttribute)
        
        Context.Attach(InstanceAtlasCoordinates)
        
        InstanceShininess = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim InstanceShininessAttribute As New GLBufferAttribute(8, 1, TKCore.Constants.ByteSize.Single, 0, 1)
        InstanceShininess.Add(InstanceShininessAttribute)
        
        Context.Attach(InstanceShininess)
        
        InstanceAlwaysLit = New GLBuffer(BufferTarget.ArrayBuffer)
        Dim InstanceAlwaysLitAttribute As New GLBufferAttribute(9, 1, TKCore.Constants.ByteSize.Single, 0, 1)
        InstanceAlwaysLit.Add(InstanceAlwaysLitAttribute)
        
        Context.Attach(InstanceAlwaysLit)
        
        Array.Resize(LightPointers, LightManager.MaximumSupportedLights)
        For Index As Int32 = 0 To LightPointers.Length - 1
            LightPointers(Index) = New LightPointer(
                $"Lights[{Index}].Position",
                $"Lights[{Index}].Direction",
                $"Lights[{Index}].AmbientColor",
                $"Lights[{Index}].DiffuseColor",
                $"Lights[{Index}].SpecularColor",
                $"Lights[{Index}].AmbientStrength",
                $"Lights[{Index}].DiffuseStrength",
                $"Lights[{Index}].SpecularStrength",
                $"Lights[{Index}].Range",
                $"Lights[{Index}].Angle",
                $"Lights[{Index}].Strength")
        Next
    End Sub
    

    
    Public Sub SetAtlasMaximum(Maximum As Vector2)
        Program.SetUniform("AtlasMaximum", Maximum)
    End Sub
    
    Public Sub SetDarknessColor(Color As Vector3)
        Program.SetUniform("DarknessColor", Color)
    End Sub
    
    Public Sub SetMinimumLight(Level As Single)
        Program.SetUniform("MinimumLightLevel", Level)
    End Sub
    
    Public Sub SetMaximumLight(Level As Single)
        Program.SetUniform("MaximumLightLevel", Level)
    End Sub
    
    Public Sub ApplyCamera(Camera As Camera)
        Program.SetUniform("View", Camera.View)
        Program.SetUniform("Projection", Camera.Projection)
    End Sub
    
    Public Sub Add(Voxel As Voxel)
        Voxels.Add(Voxel)
        Dim FutureVoxelCount As Int32 = Voxels.Count() + 1
        If FutureVoxelCount <= Matrices.Length Then Return
            
        Dim FutureBufferSize As Int32 = FutureVoxelCount * 2
        Array.Resize(Matrices,        FutureBufferSize)
        Array.Resize(Coordinates,     FutureBufferSize)
        Array.Resize(ShininessValues, FutureBufferSize)
        Array.Resize(AlwaysLitValues, FutureBufferSize)
    End Sub
    
    Public Sub Remove(Voxel As Voxel)
        Voxels.Remove(Voxel)
    End Sub
    
    Public Function Voxel(Index As Int32) As Voxel
        Return Voxels(Index)
    End Function
    
    Public Function Count() As Int32
        Return Voxels.Count
    End Function
    
    Public Function Contains(Voxel As Voxel) As Boolean
        Return Voxels.Contains(Voxel)
    End Function
    
    Public Sub Tick(Args As FrameEventArgs)
        For Each Entry In Voxels
            Entry.Tick(Args)
        Next
        
        For Each Entry In Voxels
            Entry.ApplyOrientation()
        Next
        
        For Index = 0 To Voxels.Count - 1
            Matrices(Index) = Voxels(Index).ModelMatrix
            Coordinates(Index) = Voxels(Index).AtlasCoordinate
            ShininessValues(Index) = Voxels(Index).Shininess
            AlwaysLitValues(Index) = Voxels(Index).AlwaysLit
        Next
        InstanceMatrices.Upload(Matrices, BufferUsageHint.StreamDraw)
        InstanceAtlasCoordinates.Upload(Coordinates, BufferUsageHint.StreamDraw)
        InstanceShininess.Upload(ShininessValues, BufferUsageHint.StreamDraw)
        InstanceAlwaysLit.Upload(AlwaysLitValues, BufferUsageHint.StreamDraw)
    End Sub
    
    Public Sub ApplyLights(LightManager As LightManager)
        Program.SetUniform("CurrentLightCount", LightManager.Count) : For Index = 0 To LightManager.Count - 1
            Program.SetUniform(LightPointers(Index).PositionName,         LightManager.Light(Index).Translation)
            Program.SetUniform(LightPointers(Index).DirectionName,        LightManager.Light(Index).Forward)
            Program.SetUniform(LightPointers(Index).AmbientName,          LightManager.Light(Index).AmbientColor)
            Program.SetUniform(LightPointers(Index).DiffuseName,          LightManager.Light(Index).DiffuseColor)
            Program.SetUniform(LightPointers(Index).SpecularName,         LightManager.Light(Index).SpecularColor)
            Program.SetUniform(LightPointers(Index).AmbientStrengthName,  LightManager.Light(Index).AmbientStrength)
            Program.SetUniform(LightPointers(Index).DiffuseStrengthName,  LightManager.Light(Index).DiffuseStrength)
            Program.SetUniform(LightPointers(Index).SpecularStrengthName, LightManager.Light(Index).SpecularStrength)
            Program.SetUniform(LightPointers(Index).RangeName,            LightManager.Light(Index).Range)
            Program.SetUniform(LightPointers(Index).AngleName,            LightManager.Light(Index).Angle)
            Program.SetUniform(LightPointers(Index).StrengthName,         LightManager.Light(Index).Strength)
        Next
    End Sub
    
    Public Sub Draw()
       DrawInstances(PrimitiveType.Triangles, DrawElementsType.UnsignedInt, VoxelMesh.Indices.Length, Voxels.Count)
    End Sub
    
    public Sub DrawInstances(PrimitiveType As PrimitiveType, ElementType As DrawElementsType, IndexCount As Int32, InstanceCount As Int32)
        GL.DrawElementsInstanced(PrimitiveType, IndexCount, ElementType, IntPtr.Zero, InstanceCount)
    End Sub

    Public Sub Bind()
        Context.Bind()
    End Sub
    
    Public Sub Unbind()
        Context.Unbind()
    End Sub
    
    Public Sub Dispose() Implements IDisposable.Dispose
        Context.Dispose()
    End Sub
End Class